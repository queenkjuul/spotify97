import { Device } from "./Device"
import { Track } from "./Track"

export enum RepeatState {
  off,
  track,
  context,
}

export type PlaybackState = {
  active: boolean // is device "active", which means playing, or was recently playing (paused)
  currentDevice: Device // name and ID of the currently active device
  // not enforced, but repeatState values are represented above
  repeatState: string // repeat status. "context" means repeat album/playlist (whichever is playing)
  shuffleState: boolean // true if shuffle is enabled
  progress: number // how many seconds into the current track
  playing: boolean // true if playing, false is paused/stopped
  nowPlaying: Track // data about currently playing track
  context: string // spotify ID code of the currently playing album/playlist/queue
}
