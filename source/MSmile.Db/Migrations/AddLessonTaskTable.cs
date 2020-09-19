namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates LessonTask table
    /// </summary>
    [Migration(202009192320, "Creates LessonTask table")]
    public class AddLessonTaskTable : Migration
    {
        private const string TableName = "LessonTask";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Link between Lessons and Tasks")
                .WithColumn("LessonId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Lesson", "Id")
                .WithColumn("TaskId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Task", "Id")
                .WithColumn("CompletionRate").AsInt16().NotNullable().WithDefaultValue(0);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
