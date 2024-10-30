export default class Playlist {
  public readonly name
  public readonly owner
  public readonly uri

  constructor(name, owner, uri) {
    this.name = name
    this.owner = owner
    this.uri = uri
  }
}
