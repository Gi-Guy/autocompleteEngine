using System.Xml.Linq;

namespace autocompleteEngine.Entity
{
    public class Worker
    {
        private int _id;
        private string _name = string.Empty;
        private string _workTitle = string.Empty;
        // Add image var

        public Worker()
        {

        }
        public Worker(string name, string workTitle)
        {
            this._name = name;
            this._workTitle = workTitle;
        }
        public Worker(int id, string name, string workTitle)
        {
            this._id = id;
            this._name = name;
            this._workTitle = workTitle;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string WorkTitle
        {
            get { return _workTitle; }
            set { _workTitle = value; }
        }
        public String ViewInfo
        {
            get
            {
                return $"id: {_id} Name: {_name} Work Title: {_workTitle}";
            }
        }
    }
}
