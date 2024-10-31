import { Track } from "./Track"

export default class RecentlyPlayed {
  public readonly track: Track
  public readonly context: string // URI

  constructor(track: Track, context: string) {
    this.track = track
    this.context = context
  }

  get uri() {
    return this.track.uri
  }
}
