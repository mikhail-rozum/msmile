namespace MSmile.Db.Migrations
{
    using FluentMigrator;

    /// <summary>
    /// Creates ParentPupil table.
    /// </summary>
    [Migration(202009222242, "Creates ParentPupil table")]
    public class AddParentPupilTable : Migration
    {
        private const string TableName = "ParentPupil";

        /// <inheritdoc />
        public override void Up()
        {
            this.Create.Table(TableName).WithDescription("Link between Parents and Pupils")
                .WithColumn("ParentId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Parent", "Id")
                .WithColumn("PupilId").AsInt64().NotNullable().PrimaryKey().ForeignKey("Pupil", "Id");
        }

        /// <inheritdoc />
        public override void Down()
        {
            throw new System.NotImplementedException();
        }
    }
}
