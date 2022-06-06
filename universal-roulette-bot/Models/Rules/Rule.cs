using System.Collections.Generic;
using System.Linq;
using RouletteBot.Models.Bets;

namespace RouletteBot.Models.Rules
{
    public abstract class Rule
    {
        public string RuleName { get; set; }
        public bool Fulfilled { get; set; }

        protected readonly BetEvaluationConfig EvaluationConfig;

        private IReadOnlyCollection<Bet> _bets;

        private readonly int _repeatTimes;

        private int _repeatedTimes;


        protected Rule(BetEvaluationConfig evaluationConfig, int repeatTimes = 0)
        {
            _repeatTimes = repeatTimes;
            _repeatedTimes = 0;
            Fulfilled = false;
            EvaluationConfig = evaluationConfig;
        }

        public abstract bool IsApplicable(IReadOnlyCollection<int> numbers);

        public IReadOnlyCollection<Bet> GetBets(IReadOnlyCollection<int> numbers)
        {
            _bets = GenerateBets(numbers);
            return _bets;
        }

        public void EvaluateBets(int lastNumber, int spin, Game game, IStatsLogger logger)
        {
            foreach (var bet in _bets)
            {
                logger.RecordBetResult(bet, bet.Multiplier, bet.CalculateBetResult(lastNumber), game.GameId, spin,
                    lastNumber,
                    game.RouletteType, RouletteHelper.GetLastOccurance(game.Numbers.ToArray(), lastNumber, true));
            }

            var win = _bets.Sum(bet => bet.CalculateBetResult(lastNumber));

            if (win > 0)
            {
                Fulfilled = true;
                return;
            }

            if (_repeatedTimes >= _repeatTimes)
            {
                Fulfilled = true;
            }

            _repeatedTimes++;
        }

        protected abstract IReadOnlyCollection<Bet> GenerateBets(IReadOnlyCollection<int> numbers);
    }
}