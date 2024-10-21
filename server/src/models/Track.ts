export class Track {
  public readonly title: string
  public readonly artist: string
  public readonly album: string
  public readonly duration: number
  public readonly albumArt?: string
  public readonly albumId?: string
  public readonly id?: string

  constructor(
    title: string,
    artist: string,
    album: string,
    duration: number,
    albumArt?: string,
    albumId?: string,
    id?: string
  ) {
    this.title = title
    this.artist = artist
    this.album = album
    this.duration = duration
    this.albumArt = albumArt ?? undefined
    this.albumId = albumId ?? undefined
    this.id = id ?? undefined
  }

  get uri() {
    return `spotify:track:${this.id}`
  }
}
