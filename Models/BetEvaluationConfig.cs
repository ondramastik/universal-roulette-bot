using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RouletteBot.Models
{
    public class BetEvaluationConfig
    {
        /// <summary>
        /// Indicates whether to suggest neutral bet when no bet is evaluated. Neutral bets are useful for rulettes with manual spin control. Default is true
        /// </summary>
        public bool NeutralBetOnEmpty { get; set; }

        public BetEvaluationConfig()
        {
            NeutralBetOnEmpty = true;
        }
    }
}
