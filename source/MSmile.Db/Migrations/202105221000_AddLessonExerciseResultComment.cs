namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Adds Comment field into LessonExerciseResult table.
    /// </summary>
    [Migration(202105221000, "Add Comment field into LessonExerciseResult table")]
    public class AddLessonExerciseResultComment : Migration
    {
        private const string TableName = "LessonExerciseResult";

        /// <inheritdoc />
        public override void Up()
        {
            Alter.Table(TableName).AddColumn("Comment").AsString(500).Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
        }
    }
}
