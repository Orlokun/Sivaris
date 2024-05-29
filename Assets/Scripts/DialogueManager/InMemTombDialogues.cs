using System.Collections.Generic;

namespace DialogueManager
{
    public static class InMemTombDialogues
    {
        #region Unlock Dialogues
        
        //Welcome Dialogue 1
        private const string Unlock_1_Node0 = "You have payed your respects to the heroes of old. Their souls are moved.";
        private const string Unlock_1_Node1 = "From the ground a few coins emerge.";
        
        private const string Unlock_Ha_V1 = "'Thy blood will not be spoiled by water', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V2 = "'Strike while the iron is hot', you can read in the tombstone.";
        private const string Unlock_Ha_V3 = "'Nought but mere phantoms, all we that lived, mere fleeting shadows', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V4 = "'And death, shall have no dominion.', you can read in the tombstone.";
        
        private const string Chest_1_Node0 = "Not any soul can loot these legendary treasures.";
        private const string Chest_1_Node1 = "Perhaps you'll bring the blade and unravel its secrets?";
        private const string Chest_1_Node2 = "For now, there is nothing left but wonder.";
        
        #endregion
        public static List<IDialogue> UnlockedTomb = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Unlock_1_Node0),
                    new DialogueNode(1, Unlock_1_Node1),
                    new DialogueNode(2, Unlock_Ha_V1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Unlock_1_Node0),
                    new DialogueNode(1, Unlock_1_Node1),
                    new DialogueNode(2, Unlock_Ha_V2)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Unlock_1_Node0),
                    new DialogueNode(1, Unlock_1_Node1),
                    new DialogueNode(2, Unlock_Ha_V3)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Unlock_1_Node0),
                    new DialogueNode(1, Unlock_1_Node1),
                    new DialogueNode(2, Unlock_Ha_V4)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Chest_1_Node0),
                    new DialogueNode(1, Chest_1_Node1),
                    new DialogueNode(2, Chest_1_Node2)
                }
            ),
        };
    }
}