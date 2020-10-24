namespace MSmile.Dto.Dto
{
    /// <summary>
    /// Task dto.
    /// </summary>
    public class TaskDto : BaseDto
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Difficulty level id.
        /// </summary>
        public long DifficultyLevelId { get; set; }

        /// <summary>
        /// Difficulty level name.
        /// </summary>
        public string DifficultyLevelName { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Customer description.
        /// </summary>
        public string CustomerDescription { get; set; }
    }
}
