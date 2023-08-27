using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about an ability.
    /// </summary>
    public class Ability : IAdditionalDataHolder, IParsable {

        public string Id { get; set; } = Guid.NewGuid().ToString();


        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>A URL.</summary>
        public string? Icon { get; set; }

        /// <summary>For ISO Classes, [0] is the class icon on its own, [1] is for tier 1 of the class, [2] is for tier 2 of the class, and so on.</summary>
        [NotMapped]
        public List<string>? Icons
        {
            get => Mapping.DelimitedStringToList(IconList);
            set => IconList = Mapping.ListToDelimitedString(value);
        }

        public string IconList { get; set; } = "";

        /// <summary>Object mapping level numbers (starting at 1) to AbilityLevel objects.</summary>
        //public IndexedAbilityLevels? Levels { get; set; }

        public ICollection<AbilityLevel> AbilityLevelCollection { get; set; } = new List<AbilityLevel>();

        [NotMapped]
        public Dictionary<int, AbilityLevel> AbilityLevels
        {
            get
            {
                Dictionary<int, AbilityLevel> abilityLevels = new();
                foreach (AbilityLevel abilityLevel in AbilityLevelCollection)
                {
                    abilityLevels.Add(abilityLevel.Level, abilityLevel);
                }
                return abilityLevels;
            }
        }

        //public AbilityLevel Level1 { get; set; }
        //public AbilityLevel Level2 { get; set; }
        //public AbilityLevel Level3 { get; set; }
        //public AbilityLevel Level4 { get; set; }
        //public AbilityLevel Level5 { get; set; }
        //public AbilityLevel? Level6 { get; set; }
        //public AbilityLevel? Level7 { get; set; }

        //[NotMapped]
        //public Dictionary<int,AbilityLevel> Levels
        //{
        //    get
        //    {
        //        Dictionary<int, AbilityLevel> levels = new();
        //        levels[1] = Level1;
        //        levels[2] = Level2;
        //        levels[3] = Level3;
        //        levels[4] = Level4;
        //        levels[5] = Level5;
        //        if (Level6 is not null) levels[6] = Level6;
        //        if (Level7 is not null) levels[7] = Level7;
        //        return levels;
        //    }
        //}




        /// <summary>(localized)</summary>
        public string? Name { get; set; }

        /// <summary>
        /// Instantiates a new Ability and sets the default values.
        /// </summary>
        public Ability() {
            AdditionalData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Ability CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Ability();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"icon", n => { Icon = n.GetStringValue(); } },
                {"icons", n => { Icons = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"levels", n =>
                    {
                        for (int level = 1; level <= 7; level++)
                        {
                            AbilityLevel? abilityLevel = GetChildNode.GetAbilityLevel(level.ToString(), n);
                            if (abilityLevel is null)
                            {
                                continue;
                            }
                            abilityLevel.Level = level;
                            AbilityLevelCollection.Add(abilityLevel);
                        }

                        //Level1 = GetChildNode.GetAbilityLevel("1", n);
                        //Level2 = GetChildNode.GetAbilityLevel("2", n);
                        //Level3 = GetChildNode.GetAbilityLevel("3", n);
                        //Level4 = GetChildNode.GetAbilityLevel("4", n);
                        //Level5 = GetChildNode.GetAbilityLevel("5", n);
                        //Level6 = GetChildNode.GetAbilityLevel("6", n);
                        //Level7 = GetChildNode.GetAbilityLevel("7", n);
                    }
                },
                {"name", n => { Name = n.GetStringValue(); } },
            };
        }
       
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("icon", Icon);
            writer.WriteCollectionOfPrimitiveValues<string>("icons", Icons);
            //writer.WriteObjectValue<IndexedAbilityLevels>("levels", Levels);
            writer.WriteStringValue("name", Name);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
