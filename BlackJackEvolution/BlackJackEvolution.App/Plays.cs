using System;

namespace BlackJackEvolution.App
{
    [Flags]
    public enum Plays
    {
        Stand = 0,
        Hit = 1,
        Double = 2,
        Split = 4,
        Surrender = 8,
        Insurance = 16
    }
}
