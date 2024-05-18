using System.Collections.Generic;

namespace DialogueManager
{
    public static class InMemTombDialogues
    {
        #region Unlock Dialogues
        
        //Welcome Dialogue 1
        private const string Unlock_1_Node0 = "You have payed your respects to the heroes of old. Their souls are moved.";
        private const string Unlock_1_Node1 = "From the ground a few coins emerge.";
        
        private const string Unlock_Ha_V1 = "'Hire the dev', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V2 = "'He is truly commited', you can read in the tombstone.";
        private const string Unlock_Ha_V3 = "'Pay him properly. Is not that much', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V4 = "'You gotta admit this is kind of funny', you can read in the tombstone.";
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
        };
    }
}