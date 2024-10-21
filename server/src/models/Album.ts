export class Album {
  public readonly title: string
  public readonly artist: string
  public readonly albumArt?: string
  public readonly id?: string

  constructor(title: string, artist: string, albumArt?: string, id?: string) {
    this.title = title
    this.artist = artist
    this.albumArt = albumArt ?? undefined
    this.id = id ?? undefined
  }

  get uri() {
    return `spotify:album:${this.id}`
  }
}
