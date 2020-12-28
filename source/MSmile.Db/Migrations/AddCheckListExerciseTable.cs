namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Add CheckListExercise table.
    /// </summary>
    [Migration(202012282222, "Add CheckListExercise table")]
    public class AddCheckListExerciseTable : Migration
    {
        private const string TableName = "CheckListExercise";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Link between check list and exercise")
                .WithColumn("CheckListId").AsInt64().NotNullable().PrimaryKey().ForeignKey("CheckList", "Id")
                .WithColumn("ExerciseId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Exercise", "Id")
                .WithColumn("Enabled").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
