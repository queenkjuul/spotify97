import { Album } from "./Album"
import Playlist from "./Playlist"
import { Track } from "./Track"

export default class SearchResults {
  public tracks: Array<Track>
  public albums: Array<Album>
  public playlists: Array<{ name: string; owner: string }>

  constructor(tracks, albums: Array<Album>, playlists: Array<Playlist> = []) {
    this.tracks = tracks
    this.albums = albums
    this.playlists = playlists
  }
}
