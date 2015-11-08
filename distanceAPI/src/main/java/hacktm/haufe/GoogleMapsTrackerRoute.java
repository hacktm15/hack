package hacktm.haufe;

import hacktm.haufe.initial.BaseRouteBuilder;
import hacktm.haufe.processors.CarDistanceProcessor;

import org.apache.camel.Exchange;


public class GoogleMapsTrackerRoute extends BaseRouteBuilder {
	
	private final String GOOGLE_API_KEY="AIzaSyBtjxSs8jtkIgYto7kvefTu9bZPq9zPGS0";
//	private final String GOOGLE_API_KEY2="AIzaSyCdUPRmuwAzHGN0qSCqsIy9Y-w3dmVJBYg";

	private final String GOOGLE_URI_MAPS="https://maps.googleapis.com/maps/api/directions/";
	private final String RESPONSE_TYPE="xml";

    @Override
    public void configure() throws Exception {
    	
       from("direct:getGoogleDistance")
            .removeHeader(Exchange.HTTP_PATH)
            .removeHeader(Exchange.HTTP_QUERY)
            .log("will call URL: "+ GOOGLE_URI_MAPS+RESPONSE_TYPE+"?origin=${header.start}&destination=${header.dest}&key="+GOOGLE_API_KEY)
            .setHeader(Exchange.HTTP_URI, simple(GOOGLE_URI_MAPS+RESPONSE_TYPE+"?origin=${header.start}&destination=${header.dest}&key="+GOOGLE_API_KEY))
            .to("jetty:dummy")
      	    .setProperty("distance", xpath("/DirectionsResponse/route/leg/distance/text/text()"))
      	    .log("${property.distance}")
      	    .process(new CarDistanceProcessor())
      	    
      	    ;
    }

}