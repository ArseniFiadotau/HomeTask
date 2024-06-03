using System.ComponentModel;

namespace Core.Data
{
    public enum OpenPositionMayClose
    {
        [Description("The market is moving against my position and I don't have enough equity to meet the margin requirement")]
        AgainstMyPosition,
        [Description("The market is moving in favor of my position")]
        InFavorOfMyPosition
    }
}
