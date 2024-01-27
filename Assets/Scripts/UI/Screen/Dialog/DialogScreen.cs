using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScreen : UIScreen<DialogController>
{
    private readonly string DIALOG_SCREEN_KEY = "dialogScreen";
    public override string Key => DIALOG_SCREEN_KEY;
}
