namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates Lesson table
    /// </summary>
    [Migration(202009192312, "Creates Lesson table")]
    public class AddLessonTable : Migration
    {
        private const string TableName = "Lesson";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Lessons")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("PupilId").AsInt64().NotNullable().ForeignKey("Pupil", "Id")
                .WithColumn("EmployeeId").AsInt64().NotNullable().ForeignKey("Employee", "Id")
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("FactDate").AsDateTime().Nullable()
                .WithColumn("Comment").AsString(1000).Nullable();
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
