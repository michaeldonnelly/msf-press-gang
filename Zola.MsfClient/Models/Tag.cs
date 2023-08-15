using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Kiota.Abstractions.Serialization;

namespace Zola.MsfClient.Models
{
    public abstract class Tag<T> : IParsable
        where T : Tag<T>, new()
    {

        [Required]
        [Key]
#pragma warning disable CS8618 // We want an exception if this is missing its ID
        public string Id { get; set; }
#pragma warning restore CS8618 

        public string? Name { get; set; }

        //[ForeignKey("Characters")]
        public List<CharacterInfo> Characters { get; } = new();

        public static T CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new T();
        }

        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>> {
                {"id", n =>
                    {
                        string? id = n.GetStringValue();
                        if (id is null)
                        {
                            throw new Exception($"Missing Id for {typeof(T).ToString()}");
                        }
                        Id = id;
                    }
                },
                {"name", n => { Name = n.GetStringValue(); } },
            };
        }

        public void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("name", Name);
        }

        public override string ToString()
        {
            if (Name is not null)
            {
                return Name;
            }
            else
            {
                return Id;
            }
        }
    }
}

