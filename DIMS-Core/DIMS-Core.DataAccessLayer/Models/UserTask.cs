#nullable disable

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class UserTask
    {
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }

        public virtual TaskState State { get; set; }
        public virtual TaskTrack Task { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual Task UserTaskNavigation { get; set; }
    }
}
