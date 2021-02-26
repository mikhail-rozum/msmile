namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Rename TaskSkill table to ExerciseSkill.
    /// </summary>
    [Migration(202012262114, "Rename TaskSkill table to ExerciseSkill")]
    public class RenameTaskSkillTable : Migration
    {
        private const string SchemaName = "public";
        private const string OldTableName = "TaskSkill";
        private const string NewTableName = "ExerciseSkill";

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
