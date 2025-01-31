namespace Challenges.Kyu4.SimplisticTCP_FSM;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54acc128329e634e9a000362">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5d7c35e601af060001599d37/groups/64f7a5c4867587000167af51">here</see>
/// </summary>
public class TCP
{
  private enum TcpState
    {
        CLOSED = 0,
        LISTEN,
        SYN_RCVD,
        SYN_SENT,
        ESTABLISHED,
        FIN_WAIT_1,
        CLOSING,
        FIN_WAIT_2,
        TIME_WAIT,
        CLOSE_WAIT,
        LAST_ACK
    }
    private enum TcpEvent
    {
        APP_PASSIVE_OPEN,
        APP_ACTIVE_OPEN,
        APP_SEND,
        APP_CLOSE,
        APP_TIMEOUT,
        RCV_SYN,
        RCV_ACK,
        RCV_SYN_ACK,
        RCV_FIN,
        RCV_FIN_ACK
    }

    private struct RuleSet
    {
        public (TcpEvent evt, TcpState state)[] Rules { get; }
        public RuleSet(params (TcpEvent evt, TcpState state)[] rules)
        {
            this.Rules = rules;
        }
    }
    
    private static readonly RuleSet[] StateRules;
    
    static TCP()
    {
        StateRules = new[]
        {
            new RuleSet(    //CLOSED
                (TcpEvent.APP_PASSIVE_OPEN, TcpState.LISTEN),
                (TcpEvent.APP_ACTIVE_OPEN, TcpState.SYN_SENT)),
            new RuleSet(    //LISTEN
                (TcpEvent.RCV_SYN, TcpState.SYN_RCVD),
                (TcpEvent.APP_SEND, TcpState.SYN_SENT),
                (TcpEvent.APP_CLOSE, TcpState.CLOSED)),
            new RuleSet(    //SYN_RCVD
                (TcpEvent.APP_CLOSE, TcpState.FIN_WAIT_1),
                (TcpEvent.RCV_ACK, TcpState.ESTABLISHED)),
            new RuleSet(    //SYN_SENT
                (TcpEvent.RCV_SYN, TcpState.SYN_RCVD),
                (TcpEvent.RCV_SYN_ACK, TcpState.ESTABLISHED),
                (TcpEvent.APP_CLOSE, TcpState.CLOSED)),
            new RuleSet(    //ESTABLISHED
                (TcpEvent.APP_CLOSE, TcpState.FIN_WAIT_1),
                (TcpEvent.RCV_FIN, TcpState.CLOSE_WAIT)),
            new RuleSet(    //FIN_WAIT_1
                (TcpEvent.RCV_FIN, TcpState.CLOSING),
                (TcpEvent.RCV_FIN_ACK, TcpState.TIME_WAIT),
                (TcpEvent.RCV_ACK, TcpState.FIN_WAIT_2)),
            new RuleSet((TcpEvent.RCV_ACK, TcpState.TIME_WAIT)), //CLOSING
            new RuleSet((TcpEvent.RCV_FIN, TcpState.TIME_WAIT)), //FIN_WAIT_2
            new RuleSet((TcpEvent.APP_TIMEOUT, TcpState.CLOSED)), //TIME_WAIT
            new RuleSet((TcpEvent.APP_CLOSE, TcpState.LAST_ACK)), //CLOSE_WAIT
            new RuleSet((TcpEvent.RCV_ACK, TcpState.CLOSED)) //LAST_ACK
        };
    }
      
   public static string TraverseStates(string[] events)
   {
       var state = TcpState.CLOSED;
        foreach (var evt in events.Select(Enum.Parse<TcpEvent>))
        {
            Console.WriteLine(evt.ToString());
          
            var ruleset = StateRules[(int)state];
            var ruleId = Array.FindIndex(ruleset.Rules, r => r.evt == evt);
            if (ruleId == -1) return "ERROR";

            state = ruleset.Rules[ruleId].state;
        }

        return state.ToString();
   }
}