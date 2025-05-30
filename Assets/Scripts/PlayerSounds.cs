using UnityEngine;

public class PlayerSounds : MonoBehaviour {

    private Player player;
    private float footStepsTimer;
    private float footStepsTimerMax = .1f;

    private void Start() {
        player = GetComponent<Player>();
    }

    private void Update() {
        footStepsTimer -= Time.deltaTime;
        if (footStepsTimer < 0f) {
            footStepsTimer = footStepsTimerMax;

            if (player.IsWalking()) {
                float volume = 1f;
                SoundManager.Instance.PlayFootStepsSound(player.transform.position, volume);
            }
        }
    }
}
