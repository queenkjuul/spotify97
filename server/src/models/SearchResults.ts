import { Album } from "./Album"
import { Track } from "./Track"

export default class SearchResults {
  public tracks: Array<Track>
  public albums: Array<Album>

  constructor(tracks, albums: Array<Album>) {
    this.tracks = tracks
    this.albums = albums
  }
}
