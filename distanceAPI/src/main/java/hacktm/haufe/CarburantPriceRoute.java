package hacktm.haufe;

import hacktm.haufe.initial.BaseRouteBuilder;
import hacktm.haufe.processors.CarburantPriceProcessor;

import org.apache.camel.Exchange;

public class CarburantPriceRoute extends BaseRouteBuilder {

	private final String MINING_SITE="http://www.pretbenzina.ro/pret-motorina";
	
    @Override
    public void configure() throws Exception {
    	
       from("direct:getPriceDiesel")
            .removeHeader(Exchange.HTTP_PATH)
            .removeHeader(Exchange.HTTP_QUERY)
            .log("will call URL: "+ MINING_SITE)
            .setHeader(Exchange.HTTP_URI, simple(MINING_SITE))
            .to("jetty:dummy")
      	    .process(new CarburantPriceProcessor())
      	    
      	    ;
    }

}