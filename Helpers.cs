namespace E_Commerce {
    public static class Helpers {
        public static byte[] ImageToByteArray(this Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.SaveAsJpeg(ms);
                return ms.ToArray();
            }
        }
        public static byte[] PathToByteArray(this string path, IWebHostEnvironment hostEnvironment)
        {
            Image image = Image.Load(hostEnvironment.WebRootPath + path);
            byte[] imageByte = ImageToByteArray(image);
            return imageByte;
        }
        public static Image byteArrayToImage(this byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.Load(memstr);
                return img;
            }
        }
        public static string ByteArrayToImg(this byte[] bytes) {
            string imreBase64Data = Convert.ToBase64String(bytes);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
        public static void SetJson(this ISession session, string key, object value) {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key) {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}