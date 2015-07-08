using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CodeHelper.Xml.Extension;
using CodeHelper.Xml;

namespace Project
{

    public class ProjectType
    : DataNode
    {
        public ProjectType
        ()
            : base()
        {
        }

        public ProjectType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ProjectType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ProjectType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }

        public DirectoryType CreateDirectoryType()
        {
            return this.Dom.CreateNode<DirectoryType>();
        }

        public DirectoryType Directory
        {
            get
            {
                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "DirectoryType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "Directory")
                    {
                        return new DirectoryType(node);
                    }
                }
                return null;
            }
            set
            {
                if (this.Directory != null)
                {
                    this.Directory.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "Directory";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }
        public QueryType CreateQueryType()
        {
            return this.Dom.CreateNode<QueryType>();
        }

        public QueryType Query
        {
            get
            {
                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "QueryType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "Query")
                    {
                        return new QueryType(node);
                    }
                }
                return null;
            }
            set
            {
                if (this.Query != null)
                {
                    this.Query.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "Query";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }
        public RuleSetType CreateRuleSetType()
        {
            return this.Dom.CreateNode<RuleSetType>();
        }

        public RuleSetType RuleSet
        {
            get
            {
                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "RuleSetType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "RuleSet")
                    {
                        return new RuleSetType(node);
                    }
                }
                return null;
            }
            set
            {
                if (this.RuleSet != null)
                {
                    this.RuleSet.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "RuleSet";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }
    }

    public class QueryType
    : DataNode
    {
        public QueryType
        ()
            : base()
        {
        }

        public QueryType
        (XmlNode dom)
            : base(dom)
        {
        }

        public QueryType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "QueryType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIncluded_ProperyChanged;
        public bool Included
        {
            get
            {
                if (this.Dom.Attributes["Included"] == null)
                    return default(bool);
                return this.Dom.Attributes["Included"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Included");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Included"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Included"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIncluded_ProperyChanged != null && oldValue != newValue)
                {
                    OnIncluded_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Included", oldValue, newValue);
            }
        }

        public SparqlType CreateSparqlType()
        {
            return this.Dom.CreateNode<SparqlType>();
        }

        public NodeList<SparqlType> Sparqls
        {
            get
            {
                NodeList<SparqlType> sparqls = null;
                XmlNode sparqls_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Sparqls")
                    {
                        sparqls_node = node;
                        sparqls = new NodeList<SparqlType>(node);
                        break;
                    }
                }

                if (sparqls_node != null)
                {
                    foreach (XmlNode node in sparqls_node.ChildNodes)
                    {
                        sparqls.AddChild(new SparqlType(node));
                    }
                }
                else
                {
                    sparqls = this.Dom.CreateNode<NodeList<SparqlType>>("Sparqls");

                    this.AddChild(sparqls);
                }
                return sparqls;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
        public QueryType CreateQueryType()
        {
            return this.Dom.CreateNode<QueryType>();
        }

        public NodeList<QueryType> Queries
        {
            get
            {
                NodeList<QueryType> queries = null;
                XmlNode queries_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Queries")
                    {
                        queries_node = node;
                        queries = new NodeList<QueryType>(node);
                        break;
                    }
                }

                if (queries_node != null)
                {
                    foreach (XmlNode node in queries_node.ChildNodes)
                    {
                        queries.AddChild(new QueryType(node));
                    }
                }
                else
                {
                    queries = this.Dom.CreateNode<NodeList<QueryType>>("Queries");

                    this.AddChild(queries);
                }
                return queries;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
    }

    public class SparqlType
    : DataNode
    {
        public SparqlType
        ()
            : base()
        {
        }

        public SparqlType
        (XmlNode dom)
            : base(dom)
        {
        }

        public SparqlType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "SparqlType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnContent_ProperyChanged;
        public string Content
        {
            get
            {
                if (this.Dom.Attributes["Content"] == null)
                    return default(string);
                return this.Dom.Attributes["Content"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Content");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Content"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Content"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnContent_ProperyChanged != null && oldValue != newValue)
                {
                    OnContent_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Content", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIncluded_ProperyChanged;
        public bool Included
        {
            get
            {
                if (this.Dom.Attributes["Included"] == null)
                    return default(bool);
                return this.Dom.Attributes["Included"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Included");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Included"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Included"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIncluded_ProperyChanged != null && oldValue != newValue)
                {
                    OnIncluded_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Included", oldValue, newValue);
            }
        }

    }

    public class FileType
    : DataNode
    {
        public FileType
        ()
            : base()
        {
        }

        public FileType
        (XmlNode dom)
            : base(dom)
        {
        }

        public FileType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "FileType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnFullName_ProperyChanged;
        public string FullName
        {
            get
            {
                if (this.Dom.Attributes["FullName"] == null)
                    return default(string);
                return this.Dom.Attributes["FullName"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "FullName");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("FullName"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["FullName"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnFullName_ProperyChanged != null && oldValue != newValue)
                {
                    OnFullName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("FullName", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIncluded_ProperyChanged;
        public bool Included
        {
            get
            {
                if (this.Dom.Attributes["Included"] == null)
                    return default(bool);
                return this.Dom.Attributes["Included"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Included");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Included"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Included"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIncluded_ProperyChanged != null && oldValue != newValue)
                {
                    OnIncluded_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Included", oldValue, newValue);
            }
        }

    }

    public class RuleType
    : DataNode
    {
        public RuleType
        ()
            : base()
        {
        }

        public RuleType
        (XmlNode dom)
            : base(dom)
        {
        }

        public RuleType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "RuleType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnContent_ProperyChanged;
        public string Content
        {
            get
            {
                if (this.Dom.Attributes["Content"] == null)
                    return default(string);
                return this.Dom.Attributes["Content"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Content");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Content"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Content"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnContent_ProperyChanged != null && oldValue != newValue)
                {
                    OnContent_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Content", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnInclude_ProperyChanged;
        public bool Include
        {
            get
            {
                if (this.Dom.Attributes["Include"] == null)
                    return default(bool);
                return this.Dom.Attributes["Include"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Include");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Include"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Include"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnInclude_ProperyChanged != null && oldValue != newValue)
                {
                    OnInclude_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Include", oldValue, newValue);
            }
        }

    }

    public class RuleSetType
    : DataNode
    {
        public RuleSetType
        ()
            : base()
        {
        }

        public RuleSetType
        (XmlNode dom)
            : base(dom)
        {
        }

        public RuleSetType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "RuleSetType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIncluded_ProperyChanged;
        public bool Included
        {
            get
            {
                if (this.Dom.Attributes["Included"] == null)
                    return default(bool);
                return this.Dom.Attributes["Included"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Included");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Included"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Included"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIncluded_ProperyChanged != null && oldValue != newValue)
                {
                    OnIncluded_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Included", oldValue, newValue);
            }
        }

        public RuleType CreateRuleType()
        {
            return this.Dom.CreateNode<RuleType>();
        }

        public NodeList<RuleType> Rules
        {
            get
            {
                NodeList<RuleType> rules = null;
                XmlNode rules_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Rules")
                    {
                        rules_node = node;
                        rules = new NodeList<RuleType>(node);
                        break;
                    }
                }

                if (rules_node != null)
                {
                    foreach (XmlNode node in rules_node.ChildNodes)
                    {
                        rules.AddChild(new RuleType(node));
                    }
                }
                else
                {
                    rules = this.Dom.CreateNode<NodeList<RuleType>>("Rules");

                    this.AddChild(rules);
                }
                return rules;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
        public RuleSetType CreateRuleSetType()
        {
            return this.Dom.CreateNode<RuleSetType>();
        }

        public NodeList<RuleSetType> RuleSets
        {
            get
            {
                NodeList<RuleSetType> ruleSets = null;
                XmlNode ruleSets_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "RuleSets")
                    {
                        ruleSets_node = node;
                        ruleSets = new NodeList<RuleSetType>(node);
                        break;
                    }
                }

                if (ruleSets_node != null)
                {
                    foreach (XmlNode node in ruleSets_node.ChildNodes)
                    {
                        ruleSets.AddChild(new RuleSetType(node));
                    }
                }
                else
                {
                    ruleSets = this.Dom.CreateNode<NodeList<RuleSetType>>("RuleSets");

                    this.AddChild(ruleSets);
                }
                return ruleSets;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
    }

    public class DirectoryType
    : DataNode
    {
        public DirectoryType
        ()
            : base()
        {
        }

        public DirectoryType
        (XmlNode dom)
            : base(dom)
        {
        }

        public DirectoryType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "DirectoryType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }


        public FileType CreateFileType()
        {
            return this.Dom.CreateNode<FileType>();
        }

        public NodeList<FileType> Files
        {
            get
            {
                NodeList<FileType> files = null;
                XmlNode files_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Files")
                    {
                        files_node = node;
                        files = new NodeList<FileType>(node);
                        break;
                    }
                }

                if (files_node != null)
                {
                    foreach (XmlNode node in files_node.ChildNodes)
                    {
                        files.AddChild(new FileType(node));
                    }
                }
                else
                {
                    files = this.Dom.CreateNode<NodeList<FileType>>("Files");

                    this.AddChild(files);
                }
                return files;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
        public DirectoryType CreateDirectoryType()
        {
            return this.Dom.CreateNode<DirectoryType>();
        }

        public NodeList<DirectoryType> Directories
        {
            get
            {
                NodeList<DirectoryType> directories = null;
                XmlNode directories_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Directories")
                    {
                        directories_node = node;
                        directories = new NodeList<DirectoryType>(node);
                        break;
                    }
                }

                if (directories_node != null)
                {
                    foreach (XmlNode node in directories_node.ChildNodes)
                    {
                        directories.AddChild(new DirectoryType(node));
                    }
                }
                else
                {
                    directories = this.Dom.CreateNode<NodeList<DirectoryType>>("Directories");

                    this.AddChild(directories);
                }
                return directories;
            }
            set
            {
                throw new Exception("cannot set");
            }
        }
    }
}