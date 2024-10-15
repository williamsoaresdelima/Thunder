using System.ComponentModel;

namespace TaskList.Data.Entities.Enum
{
    public enum StatusTask : byte
    {
        [Description("Pending")]
        Pending,

        [Description("In Progress")]
        InProgress,

        [Description("Finished")]
        Finished,

        [Description("Stand-By")]
        StandBy
    }
}
