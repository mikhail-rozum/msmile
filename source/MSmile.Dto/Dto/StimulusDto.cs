namespace MSmile.Dto.Dto
{
    /// <summary>
    /// Stimulus dto.
    /// </summary>
    public class StimulusDto : BaseDto
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pupil.
        /// </summary>
        public ListItemDto Pupil { get; set; }
    }
}
