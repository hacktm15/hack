package hacktm.haufe;

import hacktm.haufe.initial.BaseRouteBuilder;
import hacktm.haufe.processors.CarburantPriceProcessor;

import org.apache.camel.Exchange;

public class CarburantPriceRoute extends BaseRouteBuilder {
	
	private final String MINING_SITE="http://autotraveler.ru/en/spravka/fuel-price-in-europe.html#.Vj3l_7crJD8";
	private final String MINING_SITE2="https://www.google.ro/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=test";
	private final String MINING_SITE3="http://www.fuel-prices-europe.info/";
	
	
									  
    @Override
    public void configure() throws Exception {
    	
       from("direct:getPriceDiesel")
            .removeHeader(Exchange.HTTP_PATH)
            .removeHeader(Exchange.HTTP_QUERY)
            .log("will call URL: "+ MINING_SITE)
//            .setHeader(Exchange.CONTENT_TYPE, simple("text/html; charset=utf-8"))
//			 .setHeader(Exchange.HTTP_URI, simple(URLEncoder.encode(MINING_SITE,"utf-8")))
            .setHeader(Exchange.HTTP_URI, simple(MINING_SITE3))
            .log("{CamelHttpUri}")
            .log("fha1------>${body}")
            .to("jetty:dummy")
//            .setProperty("price", xpath("/html/body/center/table[13]/tbody/tr[45]/td[2]/text()"))
//            .log("fha2------>${body}")
//             .log(" ${property.price}")
             .log("fha2------>done")
      	    .process(new CarburantPriceProcessor())
      	    
      	    ;
    }

}