namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add LessonStimulus table.
    /// </summary>
    [Migration(202012282240, "Add LessonStimulus table")]
    public class AddLessonStimulusTable : Migration
    {
        private const string TableName = "LessonStimulus";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Stimulus and their frequency for each lesson")
                .WithColumn("LessonId").AsInt64().NotNullable().ForeignKey("Lesson", "Id")
                .WithColumn("StimulusId").AsInt64().NotNullable().ForeignKey("Stimulus", "Id")
                .WithColumn("Count").AsByte().NotNullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
