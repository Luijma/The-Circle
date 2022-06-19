using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MessageContentItem : MonoBehaviour
{
    public string receiver;
    public List<MessageItem> messageItemList = new List<MessageItem>();
    public Scrollbar scrollBar;
    public Transform contentBox;

    public void SetMessageContentInfo(Player _player)
    {
        receiver = _player.NickName;
    }
}
