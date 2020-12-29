namespace MSmile.Dto.Dto
{
    /// <summary>
    /// Check list exercise dto.
    /// </summary>
    public class CheckListExerciseDto
    {
        /// <summary>
        /// Check list id.
        /// </summary>
        public long CheckListId { get; set; }

        /// <summary>
        /// Check list.
        /// </summary>
        public CheckListDto CheckList { get; set; }

        /// <summary>
        /// Exercise id.
        /// </summary>
        public long ExerciseId { get; set; }

        /// <summary>
        /// Exercise.
        /// </summary>
        public ExerciseDto Exercise { get; set; }

        /// <summary>
        /// Active.
        /// </summary>
        public bool Active { get; set; }
    }
}
