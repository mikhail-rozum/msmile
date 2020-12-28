namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add LessonExerciseResult table.
    /// </summary>
    [Migration(202012282233, "Add LessonExerciseResult table")]
    public class AddLessonExerciseResultTable : Migration
    {
        private const string TableName = "LessonExerciseResult";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Results of execution of each exercise on a lesson")
                .WithColumn("LessonId").AsInt64().NotNullable().ForeignKey("Lesson", "Id")
                .WithColumn("ExerciseId").AsInt64().NotNullable().ForeignKey("Exercise", "Id")
                .WithColumn("Percentage").AsByte().NotNullable().WithDefaultValue(0);
                
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
