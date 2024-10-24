using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
   public VideoPlayer myVideoPlayer;
   void Start()
   {
       string videoUrl= Application.streamingAssetsPath +"/"+ "introfilm" + ".mp4";
       myVideoPlayer.url = videoUrl;
   }
}