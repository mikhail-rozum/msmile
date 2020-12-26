namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Rename LessonTask table to LessonExercise.
    /// </summary>
    [Migration(202012262109, "Rename LessonTask table to LessonExercise")]
    public class RenameLessonTaskTable : Migration
    {
        private const string SchemaName = "public";
        private const string OldTableName = "LessonTask";
        private const string NewTableName = "LessonExercise";

        /// <inheritdoc />
        public override void Up()
        {
            this.Rename.Table(OldTableName).InSchema(SchemaName).To(NewTableName);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
