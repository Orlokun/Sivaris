using System.Collections.Generic;
using DialogueManager;

namespace ShopManagement
{
    public static class UndertakerInMemDialogues
    {
        #region Welcome Dialogues
        //Welcome Dialogue 1
        private const string Welcome_1_Node0 = "It's a long time someone came...";
        private const string Welcome_1_Node1 = "This may look abandoned. But Gold is still needed around this parts.";
        private const string Welcome_1_Node2 = "*sighs with capitalism";
        
        //Welcome Dialogue 2
        private const string Welcome_2_Node0 = "It's a long time someone came through the graveyard of the old forgotten heroes.";
        private const string Welcome_2_Node1 = "This may look abandoned. But Gold is still needed around this parts.";
        private const string Welcome_2_Node2 = "*sighs with capitalism. Ok. Choose your sword.";
        #endregion

        #region Rejection Dialogues
        //Rejection Dialogue 1        
        private const string Rejection_1_Node0 = "You think you are the first broke hero around this parts?";
        private const string Rejection_1_Node1 = "Gold is what you need to get the ancient swords. Maybe near these tombs you may find some.";
        private const string Rejection_1_Node2 = "If you want a fine piece of blade, bring me at least 20 coins.";
        
        //Rejection Dialogue 1        
        private const string Rejection_2_Node0 = "This lands are expensive. You should already know that. Gold is what you need if you are looking to survive. ";
        private const string Rejection_2_Node1 = "The dead around this parts might still hide some treasures. Go give them a visit. Just be careful no to be taken with them.";
        private const string Rejection_2_Node2 = "With 20 golds you might get one of their blades. Not like they need it any more.";
        #endregion


        #region NotEnoughMoneyDialogues
        //Not enough 1
        private const string NotEnoughDough_1_Node0 = "You don't have enough gold to purchase this item.";
        private const string NotEnoughDough_1_Node1 = "Maybe try somethin cheaper. Though what's cheap costs heavily. *bug in production happens.";
        
        //Not Enough 2
        private const string NotEnoughDough_2_Node0 = "This lands are more expensive than what you have.";
        private const string NotEnoughDough_2_Node1 = "*Drops rent cost as if by accident ($950).";
        #endregion
        
        #region Already Have that
        //Already 1
        private const string AlreadyHave_1_Node0 = "You already have that one. Why on earth would I be able to sell it to you again.";
        private const string AlreadyHave_1_Node1 = "Well, if it suits you. Who am I to judge?";
        
        //Already 2
        private const string AlreadyHave_2_Node0 = "Already have that blade... Hey... I have an idea.";
        private const string AlreadyHave_2_Node1 = "Since you really like that blade, maybe you can hire the dev of this game and ask him for more!";
        #endregion
        
        #region Not a sword selected
        //NotSelected 1
        private const string NotSelected_1_Node0 = "You need to tell me which one you want before you try to buy.";
        private const string NotSelected_1_Node1 = "We can start over again if you want.";
        
        //NotSelected 2
        private const string NotSelected_2_Node0 = "Sorry I don't understand what you want to buy.";
        private const string NotSelected_2_Node1 = "Please select something before you distract me again.";
        #endregion
        
        #region Finish Purchase
        //Already 1
        private const string PurchaseFinish_1_Node0 = "A fine choice indeed. May your adventure be long.";
        private const string PurchaseFinish_1_Node1 = "Let's see if you can honor this blades old master.";
        
        //Already 2
        private const string PurchaseFinish_2_Node0 = "You may carry the blade forged by the gods themselves.";
        private const string PurchaseFinish_2_Node1 = "Use it wisely, if there's any wisdom left in this world...";
        #endregion

        
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
                    new DialogueNode(1, Rejection_1_Node1),
                    new DialogueNode(2, Rejection_1_Node2)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, Rejection_2_Node0),
                    new DialogueNode(1, Rejection_2_Node1),
                    new DialogueNode(2, Rejection_2_Node2)
                }
            ),
        };
        
        public static List<IDialogue> NotEnoughMoneyDialogues = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, NotEnoughDough_1_Node0),
                    new DialogueNode(1, NotEnoughDough_1_Node1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, NotEnoughDough_2_Node0),
                    new DialogueNode(1, NotEnoughDough_2_Node1)
                }
            ),
        };
        
        public static List<IDialogue> AlreadyHaveItemDialogues = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, AlreadyHave_1_Node0),
                    new DialogueNode(1, AlreadyHave_1_Node1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, AlreadyHave_2_Node0),
                    new DialogueNode(1, AlreadyHave_2_Node1)
                }
            ),
        };
        
        public static List<IDialogue> ChooseAnItemDialogues = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, NotSelected_1_Node0),
                    new DialogueNode(1, NotSelected_1_Node1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, NotSelected_2_Node0),
                    new DialogueNode(1, NotSelected_2_Node1)
                }
            ),
        };
        
        public static List<IDialogue> FinishPurchaseDialogue = new List<IDialogue>()
        {
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, PurchaseFinish_1_Node0),
                    new DialogueNode(1, PurchaseFinish_1_Node1)
                }
            ),
            new Dialogue(
                new List<DialogueNode>()
                {
                    new DialogueNode(0, PurchaseFinish_2_Node0),
                    new DialogueNode(1, PurchaseFinish_2_Node1)
                }
            ),
        };
    }
}