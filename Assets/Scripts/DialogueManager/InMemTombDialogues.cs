using System.Collections.Generic;

namespace DialogueManager
{
    public static class InMemTombDialogues
    {
        #region Unlock Dialogues
        
        //Welcome Dialogue 1
        private const string Unlock_1_Node0 = "You have payed your respects to the heroes of old. Their souls are moved.";
        private const string Unlock_1_Node1 = "From the ground a few coins emerge.";
        
        private const string Unlock_Ha_V1 = "'You can still hire this fair dev', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V2 = "'He was truly commited and goal-oriented', you can read in the tombstone.";
        private const string Unlock_Ha_V3 = "'If you pay him well, he'll return it a thousand times', a voice whispers in the winds and fade.";
        private const string Unlock_Ha_V4 = "'You gotta admit this is kind of funny', you can read in the tombstone.";
        
        private const string Chest_1_Node0 = "Not anyone may open this box of secrets.";
        private const string Chest_1_Node1 = "The dev is trading the key for job. Perhaps you'll unravel its secrets?";
        private const string Chest_1_Node2 = "Here is a little extra something for now.";
        
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