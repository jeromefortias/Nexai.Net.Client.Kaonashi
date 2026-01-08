namespace Localhost.AI.KaonashiWeb.Models
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public EntityBase(string? id)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                this.Id = id;
            }
            Init();
        }

        public string Id { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        private void Init()
        {

        }
    }
}

