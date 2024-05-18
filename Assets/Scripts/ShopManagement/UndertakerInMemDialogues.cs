using System.Collections.Generic;
using DialogueManager;

namespace ShopManagement
{
    public static class UndertakerInMemDialogues
    {
        //Welcome Dialogue 1
        private const string Welcome_1_Node0 = "It's a long time someone came through the graveyard of the old forgotten heroes";
        private const string Welcome_1_Node1 = "This may look abandoned. But Gold is still needed around this parts";
        private const string Welcome_1_Node2 = "*sighs with capitalism";
        
        //Welcome Dialogue 2
        private const string Welcome_2_Node0 = "It's a long time someone came through the graveyard of the old forgotten heroes";
        private const string Welcome_2_Node1 = "This may look abandoned. But Gold is still needed around this parts";
        private const string Welcome_2_Node2 = "*sighs with capitalism. Ok. Choose your sword.";
        
        //Rejection Dialogue 1        
        private const string Rejection_1_Node0 = "You think you are the first broke hero around this parts?";
        private const string Rejection_1_Node1 = "Gold is what you need to get this magic. Maybe near these tombs you may find some.";
        
        //Rejection Dialogue 1        
        private const string Rejection_2_Node0 = "This lands are expensive. ";
        private const string Rejection_2_Node1 = "Gold is what you need. The dead around this parts might still hide some treasures.";

        public static List<IDialogue> WelcomeDialogues = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Welcome_1_Node0),
                    new DialogueNode(1, Welcome_1_Node1),
                    new DialogueNode(2, Welcome_1_Node2)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Welcome_2_Node0),
                    new DialogueNode(1, Welcome_2_Node1),
                    new DialogueNode(2, Welcome_2_Node2)
                }
            ),
        };
        
        public static List<IDialogue> RejectionDialogues = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Rejection_1_Node0),
                    new DialogueNode(1, Rejection_1_Node1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Rejection_2_Node0),
                    new DialogueNode(1, Rejection_2_Node1)
                }
            ),
        };
    }
}