namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates TaskSkill table
    /// </summary>
    [Migration(202009192252, "Creates TaskSkill table")]
    public class AddTaskSkillTable : Migration
    {
        private const string TableName = "TaskSkill";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Link between Tasks and Skills")
                .WithColumn("TaskId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Task", "Id")
                .WithColumn("SkillId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Skill", "Id");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
