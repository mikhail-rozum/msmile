namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Alter lesson table.
    /// </summary>
    [Migration(202012282231, "Alter Lesson table")]
    public class AlterLessonTable : Migration
    {
        private const string TableName = "Lesson";

        /// <inheritdoc />
        public override void Up()
        {
            this.Alter.Table(TableName)
                .AddColumn("CheckListId").AsInt64().NotNullable().ForeignKey("CheckList", "Id")
                .AddColumn("Paid").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
