public class JSONParse {

public static void main(String[] args) throws Exception {
    String url = "https://api.github.com/users/vGrynishyn/repos";
    String data = readUrl(url);
    JSONArray jsonArr = new JSONArray(data);

    for (int i = 0; i < jsonArr.length(); i++) {
        JSONObject jsonObj = jsonArr.getJSONObject(i);

        System.out.println(jsonObj.get("name"));
    }

}

private static String readUrl(String urlString) throws Exception {
    BufferedReader reader = null;
    try {
        URL url = new URL(urlString);
        reader = new BufferedReader(new InputStreamReader(url.openStream()));
        StringBuffer buffer = new StringBuffer();
        int read;
        char[] chars = new char[1024];
        while ((read = reader.read(chars)) != -1)
            buffer.append(chars, 0, read);

        return buffer.toString();
    } finally {
        if (reader != null)
            reader.close();
    }
}
}
