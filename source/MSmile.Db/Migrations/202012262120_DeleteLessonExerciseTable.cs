namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Delete LessonExercise table.
    /// </summary>
    [Migration(202012262120, "Delete table LessonExercise table")]
    public class DeleteLessonExerciseTable : Migration
    {
        private const string SchemaName = "public";
        private const string TableName = "LessonExercise";

        /// <inheritdoc />
        public override void Up()
        {
            this.Delete.Table(TableName).InSchema(SchemaName);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
