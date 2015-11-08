package hacktm.haufe;

import hacktm.haufe.initial.BaseRouteBuilder;
import hacktm.haufe.processors.AirDistanceProcessor;

import org.apache.camel.Exchange;

public class SkyScannerTrackerRoute extends BaseRouteBuilder {
	
	private final String SKYS_API_KEY="a1463e07-efc9-478a-b533-342d74b41e8e";
	private final String SKYS_URI_MAPS="http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/";
//	http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/GB/EUR/en-GB/LON/TSR/2015-11-08/2015-12-13?apiKey=a1463e07-efc9-478a-b533-342d74b41e8e
	
    @Override
    public void configure() throws Exception {
    	
       from("direct:getAirRoute")
            .removeHeader(Exchange.HTTP_PATH)
            .removeHeader(Exchange.HTTP_QUERY)
            .log("will call URL: "+ SKYS_URI_MAPS+"?origin=${header.start}&destination=${header.dest}&key="+SKYS_API_KEY)
            .setHeader(Exchange.CONTENT_TYPE, constant("application/json"))
            .setHeader(Exchange.HTTP_URI, simple(SKYS_URI_MAPS+"/RO/EUR/en-GB/${header.start}/${header.dest}/${header.startDate}/${header.destDate}?apiKey="+SKYS_API_KEY))
            .to("jetty:dummy")
      	    .setProperty("price", xpath("/DirectionsResponse/route/leg/distance/text/text()"))
      	    .log("${property.distance}")
      	    .process(new AirDistanceProcessor())
      	    
      	    ;
    }

}