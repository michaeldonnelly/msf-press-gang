using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Zola.MsfClient.Models {
    /// <summary>
    /// Information about a character.
    /// </summary>
    public class CharacterInfo : IAdditionalDataHolder, IParsable {

        [Key]
        public string? Id { get; set; }

        public string Name { get; set; } = "missing name";

        /// <summary>URL</summary>
        public string? Portrait { get; set; }

        public string? Description { get; set; }

        /// <summary>Yellow stars needed to unlock the character.</summary>
        public int? UnlockStars { get; set; }

        /// <summary>Traits that show in the roster, exclusive of event traits.</summary>
        //[ForeignKey("Traits")]
        public List<Trait> Traits { get; set; } = new();

        /// <summary>Traits that do not show in the roster.</summary>
        [NotMapped]
        public List<Trait>? InvisibleTraits { get; set; } = new();

        /// <summary>Traits relevant to events.</summary>
        [NotMapped]
        public List<string>? EventTraits { get; set; }

        /// <summary>Ids of any characters summoned by this character. (Omitted for non-summoners.)</summary>
        [NotMapped]
        // TODO: figure out how to make this point to another row in the table
        public List<string>? SummonIds { get; set; }

        /// <summary>Ids of any characters that summon this character. (Omitted for non-summons.)</summary>
        //[ForeignKey(nameof(CharacterInfo))]
        [NotMapped]
        public List<string>? SummonByIds { get; set; }

#nullable disable
        public AbilityKit AbilityKit { get; set; }
#nullable enable

        public AbilityKit? EmpoweredAbilityKit { get; set; }

        public ICollection<GearTier> GearTierCollection { get; set; } = new List<GearTier>();

        [NotMapped]
        public GearTier[] GearTiers
        {
            get
            {
                GearTier[] gearTierArray = new GearTier[18];
                foreach (GearTier gearTier in GearTierCollection)
                {
                    gearTierArray[gearTier.Level] = gearTier;
                }
                return gearTierArray;
            }
        }

        #region non-DB properties
        /// <summary>Index 0 is the yellow star shard item.Indices 1-7 are the respective red star items.</summary>
        [NotMapped]
        public List<string>? StarItems { get; set; }

        [NotMapped]
        public IDictionary<string, object> AdditionalData { get; set; }

        [NotMapped]  // If it's the mission variant, we won't have it in the DB
        public bool? Mission { get; set; }

        /// <summary>Indicates the status of the character.&quot;playable&quot; = Appears in the roster.&quot;summon&quot; = Summoned by another character.&quot;war&quot; = Available in war only.&quot;operator&quot; = Used by either side to progress various missions.&quot;nue&quot; = Used for guided experiences.&quot;model&quot; = Art only.&quot;unplayable&quot; = Cannot be controlled by players in any way.&quot;other&quot; = Doesn&apos;t fit into any of the other categories.&quot;unknown&quot; = Uncategorized, in development, and/or subject to change before release.</summary>
        [NotMapped]  // If it isn't playable, we won't have it in the DB
        public CharacterInfo_status? Status { get; set; }

        [NotMapped]
        public IndexedItems? Costumes { get; set; }

       

        
        #endregion

        public CharacterInfo() {
            AdditionalData = new Dictionary<string, object>();
        }

        public override string ToString()
        {
            return $"{Name} - {Description}";
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CharacterInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CharacterInfo();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
#pragma warning disable CS8601 // Possible null reference assignment - we want an error if this happens
            return new Dictionary<string, Action<IParseNode>> {
                {"abilityKit", n => { AbilityKit = n.GetObjectValue<Zola.MsfClient.Models.AbilityKit>(Zola.MsfClient.Models.AbilityKit.CreateFromDiscriminatorValue); } },
                {"costumes", n => { Costumes = n.GetObjectValue<IndexedItems>(IndexedItems.CreateFromDiscriminatorValue); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"empoweredAbilityKit", n => { EmpoweredAbilityKit = n.GetObjectValue<Zola.MsfClient.Models.AbilityKit>(Zola.MsfClient.Models.AbilityKit.CreateFromDiscriminatorValue); } },
                {"eventTraits", n => { EventTraits = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"gearTiers", n =>
                    {                       
                        for (int i = 1; i <= 17; i++)
                        {
                            GearTier? gearTier = GetChildNode.GetGearTier(i.ToString(), n);
                            if (gearTier is null)
                            {
                                continue;
                            }
                            gearTier.Level = i;
                            GearTierCollection.Add(gearTier);
                        }                   
                    }
                },
                {"id", n => { Id = n.GetStringValue(); } },
                {"invisibleTraits", n =>
                    {
                        InvisibleTraits = n.GetCollectionOfObjectValues<Trait>(Trait.CreateFromDiscriminatorValue)?.ToList();
                    }
                },
                {"mission", n => { Mission = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"portrait", n => { Portrait = n.GetStringValue(); } },
                {"starItems", n => { StarItems = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"status", n => { Status = n.GetEnumValue<CharacterInfo_status>(); } },
                {"summonByIds", n => { SummonByIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"summonIds", n => { SummonIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"traits", n =>
                    {
                        Traits = n.GetCollectionOfObjectValues<Trait>(Trait.CreateFromDiscriminatorValue)?.ToList();
                    }
                },
                {"unlockStars", n => { UnlockStars = n.GetIntValue(); } },
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Zola.MsfClient.Models.AbilityKit>("abilityKit", AbilityKit);
            writer.WriteObjectValue<IndexedItems>("costumes", Costumes);
            writer.WriteStringValue("description", Description);
            writer.WriteObjectValue<Zola.MsfClient.Models.AbilityKit>("empoweredAbilityKit", EmpoweredAbilityKit);
            writer.WriteCollectionOfPrimitiveValues<string>("eventTraits", EventTraits);
            //writer.WriteObjectValue<IndexedGearTiers>("gearTiers", GearTiers);
            writer.WriteStringValue("id", Id);
            writer.WriteCollectionOfObjectValues("invisibleTraits", InvisibleTraits);
            writer.WriteBoolValue("mission", Mission);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("portrait", Portrait);
            writer.WriteCollectionOfPrimitiveValues<string>("starItems", StarItems);
            writer.WriteEnumValue<CharacterInfo_status>("status", Status);
            writer.WriteCollectionOfPrimitiveValues<string>("summonByIds", SummonByIds);
            writer.WriteCollectionOfPrimitiveValues<string>("summonIds", SummonIds);
            writer.WriteCollectionOfObjectValues("traits", Traits);
            writer.WriteIntValue("unlockStars", UnlockStars);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
