package by.belstu.it;

import by.belstu.it.Lab5.Language;
import by.belstu.it.Lab5.Parse.DOM;
import by.belstu.it.Lab5.Parse.SAX;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.xml.sax.SAXException;

import javax.xml.XMLConstants;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.stream.IntStream;

public class Main {
    public static class Valid {
        public static boolean validateXMLSchema(String xsdPath, String xmlPath) {
            try {
                var factory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
                var schema = factory.newSchema(new File(xsdPath));
                var validator = schema.newValidator();
                validator.validate(new StreamSource(new File(xmlPath)));
            } catch (IOException | SAXException e) {
                System.out.println("Exception: " + e.getMessage());
                return false;
            }

            return true;
        }
    }

    public static void main(String[] args) throws Exception {
        System.out.println(Valid.validateXMLSchema("files/XML.xsd", "files/XML.xml"));
        var languages = new Language("Senior-pomidor", 1);

        //DOM
        System.out.println("DOM");
        var dom = new DOM();
        dom.startParser("files/Language.xml");
        System.out.println();

        //SAX
        System.out.println("SAX");
        var factory = SAXParserFactory.newInstance();
        var parser = factory.newSAXParser();
        var sax = new SAX();
        parser.parse(new File("files/Language.xml"), sax);
        var language = sax.getResult();
        System.out.println(language.toString());

        var gson = new GsonBuilder().setPrettyPrinting().create();
        String jsonString = gson.toJson(languages);

        try (FileWriter writer = new FileWriter("Json.json", false)) {
            System.out.println("json " + jsonString);
            writer.write(jsonString);
            writer.flush();
        } catch (IOException ex) {
            System.out.println(ex.getMessage());
        }

        var newLanguage = gson.fromJson(jsonString, Language.class);
        System.out.println(newLanguage.getName());

        IntStream.of(50, 60, 70, 80, 90, 100, 110, 120).filter(x -> x < 90).map(x -> x + 10)
                .limit(3).forEach(System.out::print);
    }
}
