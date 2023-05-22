namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        private readonly List<string> _identifiers = new();

        public IdentifiableObject(string[] idents)
        {
            foreach (string ident in idents)

            {
                _identifiers.Add(ident.ToLower());
            }
        }

        public IdentifiableObject()
        {

        }

        public bool AreYou(string id) => _identifiers.Contains(id.ToLower());

        public string FirstID
        {
            get
            {
                if (_identifiers.Count == 0)
                
                    return "";
                
                else
                
                    return _identifiers.First();
                
            }
        }

        public void AddIdentifier(string id) => _identifiers.Add(id.ToLower());
    }
}
