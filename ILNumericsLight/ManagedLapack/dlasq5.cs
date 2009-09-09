﻿#region ORIGINS, COPYRIGHTS, AND LICENSE
/*

This C# version of LAPACK is derivied from http://www.netlib.org/clapack/,
and the original copyright and license is as follows:

Copyright (c) 1992-2008 The University of Tennessee.  All rights reserved.
$COPYRIGHT$ Additional copyrights may follow $HEADER$

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

- Redistributions of source code must retain the above copyright
  notice, this list of conditions and the following disclaimer. 
  
- Redistributions in binary form must reproduce the above copyright
  notice, this list of conditions and the following disclaimer listed
  in this license in the documentation and/or other materials
  provided with the distribution.
  
- Neither the name of the copyright holders nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT  
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT  
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
#endregion

public partial class ManagedLapack
{
    public static unsafe int dlasq5(int i0, int n0, double* z__, int pp, double tau, double dmin__,
        ref double dmin1, ref double dmin2, ref double dn, ref double dnm1, ref double dnm2, bool ieee)
    {
        /* System generated locals */
        int i__1;
        double d__1, d__2;

        /* Local variables */
        double d__;
        int j4, j4p2;
        double emin, temp;

        /* Parameter adjustments */
        --z__;

        /* Function Body */
        if (n0 - i0 - 1 <= 0.0) {
	    return 0;
        }

        j4 = (i0 << 2) + pp - 3;
        emin = z__[j4 + 4];
        d__ = z__[j4] - tau;
        dmin__ = d__;
        dmin1 = -z__[j4];

        if (ieee) {

    /*        Code for IEEE arithmetic. */

	    if (pp == 0.0) {
	        i__1 = n0 - 3 << 2;
	        for (j4 = i0 << 2; j4 <= i__1; j4 += 4) {
		    z__[j4 - 2] = d__ + z__[j4 - 1];
		    temp = z__[j4 + 1] / z__[j4 - 2];
		    d__ = d__ * temp - tau;
		    dmin__ = min(dmin__,d__);
		    z__[j4] = z__[j4 - 1] * temp;
    /* Computing MIN */
		    d__1 = z__[j4];
		    emin = min(d__1,emin);
    /* L10: */
	        }
	    } else {
	        i__1 = n0 - 3 << 2;
	        for (j4 = i0 << 2; j4 <= i__1; j4 += 4) {
		    z__[j4 - 3] = d__ + z__[j4];
		    temp = z__[j4 + 2] / z__[j4 - 3];
		    d__ = d__ * temp - tau;
		    dmin__ = min(dmin__,d__);
		    z__[j4 - 1] = z__[j4] * temp;
    /* Computing MIN */
		    d__1 = z__[j4 - 1];
		    emin = min(d__1,emin);
    /* L20: */
	        }
	    }

    /*        Unroll last two steps. */

	    dnm2 = d__;
	    dmin2 = dmin__;
	    j4 = (n0 - 2 << 2) - pp;
	    j4p2 = j4 + (pp << 1) - 1;
	    z__[j4 - 2] = dnm2 + z__[j4p2];
	    z__[j4] = z__[j4p2 + 2] * (z__[j4p2] / z__[j4 - 2]);
	    dnm1 = z__[j4p2 + 2] * (dnm2 / z__[j4 - 2]) - tau;
	    dmin__ = min(dmin__,dnm1);

	    dmin1 = dmin__;
	    j4 += 4;
	    j4p2 = j4 + (pp << 1) - 1;
	    z__[j4 - 2] = dnm1 + z__[j4p2];
	    z__[j4] = z__[j4p2 + 2] * (z__[j4p2] / z__[j4 - 2]);
	    dn = z__[j4p2 + 2] * (dnm1 / z__[j4 - 2]) - tau;
	    dmin__ = min(dmin__,dn);

        } else {

    /*        Code for non IEEE arithmetic. */

	    if (pp == 0.0) {
	        i__1 = n0 - 3 << 2;
	        for (j4 = i0 << 2; j4 <= i__1; j4 += 4) {
		    z__[j4 - 2] = d__ + z__[j4 - 1];
		    if (d__ < 0.0) {
		        return 0;
		    } else {
		        z__[j4] = z__[j4 + 1] * (z__[j4 - 1] / z__[j4 - 2]);
		        d__ = z__[j4 + 1] * (d__ / z__[j4 - 2]) - tau;
		    }
		    dmin__ = min(dmin__,d__);
    /* Computing MIN */
		    d__1 = emin;
            d__2 = z__[j4];
		    emin = min(d__1,d__2);
    /* L30: */
	        }
	    } else {
	        i__1 = n0 - 3 << 2;
	        for (j4 = i0 << 2; j4 <= i__1; j4 += 4) {
		    z__[j4 - 3] = d__ + z__[j4];
		    if (d__ < 0.0) {
		        return 0;
		    } else {
		        z__[j4 - 1] = z__[j4 + 2] * (z__[j4] / z__[j4 - 3]);
		        d__ = z__[j4 + 2] * (d__ / z__[j4 - 3]) - tau;
		    }
		    dmin__ = min(dmin__,d__);
    /* Computing MIN */
            d__1 = emin;
            d__2 = z__[j4 - 1];
		    emin = min(d__1,d__2);
    /* L40: */
	        }
	    }

    /*        Unroll last two steps. */

	    dnm2 = d__;
	    dmin2 = dmin__;
	    j4 = (n0 - 2 << 2) - pp;
	    j4p2 = j4 + (pp << 1) - 1;
	    z__[j4 - 2] = dnm2 + z__[j4p2];
	    if (dnm2 < 0.0) {
	        return 0;
	    } else {
	        z__[j4] = z__[j4p2 + 2] * (z__[j4p2] / z__[j4 - 2]);
	        dnm1 = z__[j4p2 + 2] * (dnm2 / z__[j4 - 2]) - tau;
	    }
	    dmin__ = min(dmin__,dnm1);

	    dmin1 = dmin__;
	    j4 += 4;
	    j4p2 = j4 + (pp << 1) - 1;
	    z__[j4 - 2] = dnm1 + z__[j4p2];
	    if (dnm1 < 0.0) {
	        return 0;
	    } else {
	        z__[j4] = z__[j4p2 + 2] * (z__[j4p2] / z__[j4 - 2]);
	        dn = z__[j4p2 + 2] * (dnm1 / z__[j4 - 2]) - tau;
	    }
	    dmin__ = min(dmin__,dn);

        }

        z__[j4 + 2] = dn;
        z__[(n0 << 2) - pp] = emin;
        return 0;
    } 
}

