export default class UserDetailsModel {
    constructor(data) {
        this.userId = data.id,
        this.userLogin = data.login,
        this.userName = data.name,
        this.wallet = data.wallet
    }
  }
  