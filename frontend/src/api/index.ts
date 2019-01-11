import Axios from 'axios'

Axios.defaults.timeout = 180000

interface IConfig {
  baseURL: string,
  headers: Object
}

export default class Api {
  public static axios(_path: string, _data?: any) {
    let jsonData: string = ''
    if (_data) {
      jsonData = JSON.stringify(_data)
    }
    // let fromData = new FormData()
    // for (const key in _data) {
    //   if (_data.hasOwnProperty(key)) {
    //     const element = _data[key]
    //     fromData.append(key, element)
    //   }
    // }

    /**
     * 配置参数
     */
    let config: IConfig = {
      baseURL: 'http://127.0.0.1:5000/',
      headers: {
        'cms-channel': 0
      }
    }

    return Axios.request({
      method: 'POST',
      baseURL: config.baseURL,
      url: _path,
      data: jsonData,
      headers: config.headers
    })
  }
}
