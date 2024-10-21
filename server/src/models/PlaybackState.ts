import { Device } from "./Device"
import { Track } from "./Track"

export enum RepeatState {
  off,
  track,
  context,
}

export type PlaybackState = {
  active: boolean
  currentDevice: Device
  repeatState: string
  shuffleState: boolean
  progress: number
  playing: boolean
  nowPlaying: Track
  context: string
}
